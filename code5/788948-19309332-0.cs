    using System.Collections.Generic;
    using System.Collections;
    using System.Data.SqlTypes;
    using System.Data.SqlClient;
    using Microsoft.SqlServer.Server;
    using System;
    using System.Data;
    namespace AFLFootballCLR
    {
        public partial class LadderUserDefinedFunctions
        {
            private class Ladder
            {
                public SqlInt32 Id;
                public SqlInt32 TeamId;
                public SqlInt32 Played;
                public SqlInt32 Won;
                public SqlInt32 Draw;
                public SqlInt32 Lost;
                public SqlInt32 PtsFor;
                public SqlInt32 PtsAgainst;
                public SqlInt32 Pts;
                public Ladder(SqlInt32 id, SqlInt32 teamId, SqlInt32 played, SqlInt32 won, SqlInt32 draw, SqlInt32 lost, SqlInt32 ptsFor, SqlInt32 ptsAgainst, SqlInt32 pts)
                {
                    this.Id = id;
                    this.TeamId = teamId;
                    this.Played = played;
                    this.Won = won;
                    this.Draw = draw;
                    this.Lost = lost;
                    this.PtsFor = ptsFor;
                    this.PtsAgainst = ptsAgainst;
                    this.Pts = pts;
                }
            }
            [SqlFunction(DataAccess = DataAccessKind.Read, FillRowMethodName = "Ladder_FillRow", TableDefinition = "Id int, TeamId int, Played int, Won int, Draw int, Lost int, PtsFor int, PtsAgainst int, Pts int")]
            public static IEnumerable GetLadder(SqlInt32 s)
            {
                //int season = s;
                int iplayed = 0;
                int iwon = 0;
                int idraw = 0;
                int ilost = 0;
                int iforPts = 0;
                int iagainstPts = 0;
                int ipts = 0;
                int tempId = 0;
                Dictionary<int, string> withTeam = new Dictionary<int, string>();
                string connectionString = "Data Source=EAGLE;Initial Catalog=AFLFooty;Persist Security Info=True;User ID=sa;Password=Colinmck0708";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var teamsFromDb = new SqlCommand("Select Id, TeamName From Teams", connection))
                    {
                        using (var teamReader = teamsFromDb.ExecuteReader())
                        {
                            while (teamReader.Read())
                            {
                                int teamId = teamReader.GetInt32(0);
                                string teamName = teamReader.GetString(1);
                                withTeam.Add(teamId, teamName);
                            }
                            teamReader.Close();
                            foreach (KeyValuePair<int, string> kvp in withTeam)
                            {
                                int TeamId = kvp.Key;
                                string teamName = kvp.Value;
                                if (teamName != "Bye")
                                {
                                    using (var resultsFromDb = new SqlCommand("SELECT QtrByQtrs.Fixture_ID, QtrByQtrs.HPoints, QtrByQtrs.APoints, Fixtures.HomeID, Fixtures.AwayID FROM QtrByQtrs INNER JOIN Fixtures ON QtrByQtrs.Fixture_ID = Fixtures.ID WHERE ((Fixtures.HomeID = " + TeamId + ") AND (QtrByQtrs.Qtr = 4) AND (Fixtures.SeasonID = @s)) OR ((Fixtures.AwayID = " + TeamId + ") AND (QtrByQtrs.Qtr = 4) AND (Fixtures.SeasonID = @s))", connection))
                                    {
                                        using (var resultsReader = resultsFromDb.ExecuteReader())
                                        {
                                            while (resultsReader.Read())
                                            {
                                                if (resultsReader.GetInt32(3) == TeamId)
                                                {
                                                    if (!(Convert.IsDBNull(resultsReader.GetInt32(1))) & !(Convert.IsDBNull(resultsReader.GetInt32(2))))
                                                    {
                                                        iplayed += 1;
                                                        if (resultsReader.GetInt32(1) > resultsReader.GetInt32(2))
                                                        {
                                                            iwon += 1;
                                                            ipts += 4;
                                                        }
                                                        else if (resultsReader.GetInt32(1) < resultsReader.GetInt32(2))
                                                        {
                                                            ilost += 1;
                                                        }
                                                        else
                                                        {
                                                            idraw += 1;
                                                            ipts += 2;
                                                        }
                                                        iforPts += resultsReader.GetInt32(1);
                                                        iagainstPts += resultsReader.GetInt32(2);
                                                    }
                                                }
                                                else
                                                {
                                                    if (!(Convert.IsDBNull(resultsReader.GetInt32(1))) & !(Convert.IsDBNull(resultsReader.GetInt32(2))))
                                                    {
                                                        iplayed += 1;
                                                        if (resultsReader.GetInt32(1) < resultsReader.GetInt32(2))
                                                        {
                                                            iwon += 1;
                                                            ipts += 4;
                                                        }
                                                        else if (resultsReader.GetInt32(1) > resultsReader.GetInt32(2))
                                                        {
                                                            ilost += 1;
                                                        }
                                                        else
                                                        {
                                                            idraw += 1;
                                                            ipts += 2;
                                                        }
                                                        iforPts += resultsReader.GetInt32(2);
                                                        iagainstPts += resultsReader.GetInt32(1);
                                                    }
                                                }
                                            }
                                            resultsReader.Close();
                                        }
                                    }
                                }
                                if (teamName != "Bye")
                                {
                                    yield return new Ladder(id: tempId, teamId: TeamId, played: iplayed, won: iwon, draw: idraw, lost: ilost, ptsFor: iforPts, ptsAgainst: iagainstPts, pts: ipts);
                                    tempId += 1;
                                }
                                iplayed = 0;
                                iwon = 0;
                                idraw = 0;
                                ilost = 0;
                                iforPts = 0;
                                iagainstPts = 0;
                                ipts = 0;
                            }
                        }
                    }
                }
            }
            public static void Ladder_FillRow(object ladderObj, out SqlInt32 id, out SqlInt32 teamId, out SqlInt32 played, out SqlInt32 won, out SqlInt32 draw, out SqlInt32 lost, out SqlInt32 ptsFor, out SqlInt32 ptsAgainst, out SqlInt32 pts)
            {
                var l = (Ladder)ladderObj;
                id = l.Id;
                teamId = l.TeamId;
                played = l.Played;
                won = l.Won;
                draw = l.Draw;
                lost = l.Lost;
                ptsFor = l.PtsFor;
                ptsAgainst = l.PtsAgainst;
                pts = l.Pts;
            }
        }
    };
