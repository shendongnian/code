    if (System.IO.File.Exists(@"D:/finaltest12.csv"))
            {
                string fileoldPath="D:\\finaltest12.csv";
            string Todaysdate ="E:\\";
            bool isExists = System.IO.Directory.Exists(Todaysdate);
            if (!isExists)
                System.IO.Directory.CreateDirectory(Todaysdate);
            System.IO.File.Move(fileoldPath, Todaysdate+"\\finaltest12.csv");
            }
