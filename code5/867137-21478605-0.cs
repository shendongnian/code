    public class NoteGenerator
    {
        private readonly ICurrentDateProvider currentDateProvider;
        public NoteGenerator(ICurrentDateProvider )currentDateProvider
        {
            this.currentDateProvider = currentDateProvider;
        }
    
        public string GenerateNote()
        {
            var currentDate = currentDateProvider.Now;
            // ...
