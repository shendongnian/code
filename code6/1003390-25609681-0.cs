                List<int> IDs = (from id in DataGridRegisteredUsers.SelectedCells
                select id.Item.ToString()
                into Input
                select Input.Split(new[] {',', '=', '}', '{'}, StringSplitOptions.RemoveEmptyEntries)
                into OutPut
                select Convert.ToInt32(OutPut[1])).ToList();
            foreach (int userID in IDs)
            {
                dbEntities = new BASUEntities();
                RelCU findQ = (from f in dbEntities.RelCUs
                    where f.UserID == userID && f.CourseID == currCourse.CourseID
                    select f).SingleOrDefault();
                dbEntities.RelCUs.Remove(findQ);
                dbEntities.SaveChanges();
            }
