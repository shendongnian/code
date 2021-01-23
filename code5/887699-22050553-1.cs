    public class DataFileLoad
    {
        //Public jagged array variables
        public string[][] aConfJag = null;
        public string[][] aPartJag = null;
        public string[][] aTypeJag = null;
        public string[][] aWkshpJag = null;
        public string[][] aWorkJag = null;
        public void loadFiles()
        {
            //The path of our exectuable
            string exePath = Application.StartupPath;
            //Set our working directory to our exe path for file reading
            Directory.SetCurrentDirectory(exePath);
            string[] aConferences = File.ReadAllLines(@"DATA\CONFERENCES.txt");
            string[] aParticipants = File.ReadAllLines(@"DATA\PARTICIPANTS.txt");
            string[] aType = File.ReadAllLines(@"DATA\TYPE.txt");
            string[] aWkshpReg = File.ReadAllLines(@"DATA\WKSHP_REGISTRATIONS.txt");
            string[] aWorkshops = File.ReadAllLines(@"DATA\WORKSHOPS.txt");
            //Make our arrays jagged for easier processing
            aConfJag  = aConferences.Select(line => line.Split(',').ToArray()).ToArray();
            aPartJag  = aParticipants.Select(line => line.Split(',').ToArray()).ToArray();
            aTypeJag  = aType.Select(line => line.Split(',').ToArray()).ToArray();
            aWkshpJag = aWkshpReg.Select(line => line.Split(',').ToArray()).ToArray();
            aWorkJag  = aWorkshops.Select(line => line.Split(',').ToArray()).ToArray();
        }
    }
