        // create list of containers
        List<Containerdetails> containers = new  List<Containerdetails>();
        using (StreamReader sr = new StreamReader("c:/containervalues.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                 // create new instance of container for each line in file
                 Containerdetails container = new Containerdetails();
                 string[] Parts = line.Split(' ');
                 // set non-static properties of container
                 container.cocnum = Parts[0];  
                 container.colength = Convert.ToDouble(Parts[1]);  
                 container.coheight = Convert.ToDouble(Parts[2]);  
                 container.codepth = Convert.ToDouble(Parts[3]);  
                 container.covolume = Convert.ToDouble(Parts[4]);
                 // add container to list of containers
                 containers.Add(container);
            }
        }
