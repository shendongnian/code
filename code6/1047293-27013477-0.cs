            for (int i = 0; i< studentData.Count; i++)
            {
                var item = studentData[i];
                if (item.Marks == "90")
                {                    
                    studentData.Insert(i, new Student { Id = item.Id, Name = item.Name + "(smart one)", Section = item.Section, Marks = item.Marks});                    
                    i++;
                }
            }
