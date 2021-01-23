    namespace SudokuTest
    {
        using System.Collections.Generic;
        using System.Linq;
        using System.Threading;
        public class SudokuConcurrentService : ISudokuConcurrentService
        {
            static int playerCount = 0;
            static List<Player> PlayersList = null;
            static object ListLock = new object();
            const int TimeLimit = 120;
            static ManualResetEvent AllPlayerResponseWait = new ManualResetEvent(false);
            public SudokuGame ClientConnect()
            {
                lock (ListLock)
                {
                    if (PlayersList != null)
                    {
                        // Already received a completed game response -- no new players.
                        return null;
                    }
                }
                return new SudokuGame()
                    {
                        PlayerID = "Player " + Interlocked.Increment(ref playerCount).ToString(),
                        TimeLimitInSeconds = TimeLimit
                    };
            }
            public List<Player> GetListOfWinners(int SentScore, string _SentPlayerID)
            {
                lock (ListLock)
                {
                    // Initialize the list.
                    if (PlayersList == null) PlayersList = new List<Player>();
                    //Add to the List 
                    PlayersList.Add(new Player { PlayerID = _SentPlayerID, Score = SentScore });
                }
                // Now decrement through the list of players to await all responses.
                if (Interlocked.Decrement(ref playerCount) == 0)
                {
                    // All responses received, unlock the wait.
                    AllPlayerResponseWait.Set();
                }
                // Wait on all responses, as necessary, up to 150% the timeout (no new players allowed one responses received, 
                // so the 150% should allow time for the last player to receive game and send response, but if any players have 
                // disconnected, we don't want to wait indefinitely).
                AllPlayerResponseWait.WaitOne(TimeLimit * 1500);
                //Order It
                List<Player> SortedList = PlayersList.OrderByDescending(p => p.Score).ToList();
                // sent fULL SORTHEDlist to the Clients
                return SortedList;
            }
        }
    }
