    namespace Test
    {
        using System;
        using System.Data;
        using System.Data.SqlClient;
        using System.Globalization;
    
        /// <summary>
        /// 
        /// </summary>
        public class Program
        {
            /// <summary>
            /// 
            /// </summary>
            public unsafe static void Main()
            {
                // Change the connection string to specify your server. 
                // Probably you won't need an initial catalog because this
                // program uses a temp table
                string connStr = "Integrated Security=True";
                // The temp table is called #Temp . It will cease to exist at the end 
                // of the program automatically
                // Two columns, DateTimeOffset and ShortDateTimeOffset
                string query = @"CREATE TABLE #Temp (DateTimeOffset datetimeoffset(7) NOT NULL, ShortDateTimeOffset datetimeoffset(6) NOT NULL);INSERT INTO #Temp VALUES (@DT1, @DT2);SELECT * FROM #Temp";
    
                using (var connection = new SqlConnection(connStr))
                using (var command = new SqlCommand(query, connection))
                {
                    const string dtString = "2013-08-15 09:19:07.2459675 -04:00";
                    const string dtFormat = "yyyy-MM-dd HH:mm:ss.fffffff zzz";
    
                    DateTimeOffset dt = DateTimeOffset.Parse(dtString, CultureInfo.InvariantCulture);
    
                    string dtString2 = dt.ToString(dtFormat, CultureInfo.InvariantCulture);
    
                    Console.WriteLine("Sending          : {0}", dtString2);
    
                    // Just to be sure!
                    if (dtString != dtString2)
                    {
                        throw new Exception("Problem in conversion");
                    }
    
                    command.Parameters.Add("@DT1", SqlDbType.DateTimeOffset).Value = dt;
                    command.Parameters.Add("@DT2", SqlDbType.DateTimeOffset).Value = dt;
    
                    try
                    {
                        connection.Open();
    
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DateTimeOffset dtRec1 = (DateTimeOffset)reader[0];
                                DateTimeOffset dtRec2 = (DateTimeOffset)reader[1];
    
                                string dtRecString1 = dtRec1.ToString(dtFormat, CultureInfo.InvariantCulture);
                                string dtRecString2 = dtRec2.ToString(dtFormat, CultureInfo.InvariantCulture);
    
                                Console.WriteLine("Receiving (long) : {0}", dtRecString1);
                                Console.WriteLine("Receiving (short): {0}", dtRecString2);
    
                                if (dtRec1 != dt)
                                {
                                    throw new Exception("Difference between DateTimeOffset(.NET) and DateTimeOffset(sql)");
                                }
    
                                if (Math.Abs(dtRec2.Ticks - dt.Ticks) > 10)
                                {
                                    throw new Exception("Too much difference between DateTimeOffset(.NET) and DateTimeOffset(6)(sql)");
                                }
    
                                if (reader.Read())
                                {
                                    throw new Exception("Too many rows");
                                }
                            }
                            else
                            {
                                throw new Exception("No rows");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
