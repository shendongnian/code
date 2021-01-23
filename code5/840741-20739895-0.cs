     class Program
            {
                static void Main(string[] args)
                {
                    DataTable dtName = new DataTable();
                    dtName.Columns.Add("Code");
                    dtName.Columns.Add("FirstName");
                    dtName.Columns.Add("lastName");
    
                    dtName.Rows.Add("1", "Abhishek", "Shukla");
                    dtName.Rows.Add("2", "Deepak", "Singh");
                    dtName.Rows.Add("3", "Vinay", "Negi");
    
                    DataTable dtHomeTowns = new DataTable();
                    dtHomeTowns.Columns.Add("Code");
                    dtHomeTowns.Columns.Add("HomeTown");
                    dtHomeTowns.Columns.Add("State");
    
                    dtHomeTowns.Rows.Add("1", "Ajmer", "Rajasthan");
                    dtHomeTowns.Rows.Add("2", "Bhiwadi", "Rajasthan");
                    dtHomeTowns.Rows.Add("3", "Guwahati", "Orissa");
    
                    var list = (from names in dtName.AsEnumerable()
                                join town in dtHomeTowns.AsEnumerable() on names["Code"] equals town["Code"]
                                select new
                                {
                                    Code = names["Code"],
                                    FirstName = names["FirstName"],
                                    lastName = names["lastName"],
                                    HomeTown = town["HomeTown"],
                                    State = town["State"],
                                }).ToList();
                    foreach (var item in list)
                    {
                        Console.WriteLine(String.Format("Code:{0}, FirstName: {1},LastName :                 {2},HomeTown:{3},State:{4}", item.Code, item.FirstName, item.lastName, item.HomeTown, item.State));
                    }
    
                    Console.ReadKey();
                }
            }
