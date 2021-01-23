     var content = new List<string>();
            using (StreamReader reader = new StreamReader(path)) 
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    content.Add(line);
                    line = reader.ReadLine();          //read in all lines
                }
            }
    //var content = File.ReadAllLines(path, Encoding.ASCII); //bad practice, see comments
    var vaildContent = (from val in content                       //specify source ("content"), create temporary var ("val") for processing
                                    where val.Split(new []{","},  StringSplitOptions.RemoveEmptyEntries).Length == 2  // condition(s)
                                    select val).ToList(); //If condition is true, slect the object
