    namespace RockPaperScissor.GameEngine
    {
        public enum Move
        {
            Rock = 0,
            Paper = 1,
            Scissor = 2
        }
    
        public enum MoveResult
        {
            PlayerWon,
            ComputerWon,
            Draw
        }
    
        public class RPSEngine
        {
            public Move ComputerMove { get; set; }
            public Move PlayerMove { get; set; }
    
            public MoveResult Result
            {
                get
                {
                    if(ComputerMove == PlayerMove)
                    {
                        return MoveResult.Draw;
                    }
                    else if(ComputerMove > PlayerMove || (ComputerMove == Move.Rock && PlayerMove == Move.Scissor))
                    {
                        return MoveResult.ComputerWon;
                    }
                    else
                    {
                        return MoveResult.PlayerWon;
                    }
                }
            }
        }
    }
