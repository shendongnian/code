    String StudentInfo = System.IO.File.ReadAllText("Students.txt");
        StreamWriter changeFile = new StreamWriter("Students.txt", true);
                
               
                string newStudent = "(LIST (LIST 'Malachi 'Constant 'A ) '8128675309 'iwishihadjessesgirl@mail.usi.edu 4.0 )";
                // this is where I am getting stumped
                if (StudentInfo.Contains(newStudent))
                {
                    changeFile.Close();
                }
                else
                {
                    changeFile.WriteLine(newStudent);
                    changeFile.Close();
                }
