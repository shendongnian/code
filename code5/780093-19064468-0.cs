    public class Images
        {      
            public string CurrentImage { get; set; }
            public string NextImage { get; set; }
            public string PreviousImage { get; set; }
            public string CurrentImagePhysicalName { get; set; }
            public Images(string currentImagePhysicalName, string Current, string Next, string Previous)
            {
                this.CurrentImagePhysicalName = currentImagePhysicalName;
                this.CurrentImage = Current;
                this.NextImage = Next;
                this.PreviousImage = Previous;
            }
        } 
  
