    public class DisplayEntiry
    {
        public void Initialize()
        {
            var entity = new Entity();
            entity.PropertyChanged += DisplayName;
            entity.Name = "Alan Bennett";  
            // This will cause DisplayName to write "Alan Bennett" to the console
        }
    
        private void DisplayName(object sender, PropertyChangedEventArgs e)
        {
            Console.Writeline(e.Name);
        }
    
    }
