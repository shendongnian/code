        private static List<GetEmployees_Result> GetEmployeeList()
        {
            using (var db = new DBEntities())
            {
                //do some crazy Linq
                ObjectResult<GetEmployees_Result> listOfEmployees = db.GetEmployees("USA");
                return listOfEmployees.ToList();
            }
        }
