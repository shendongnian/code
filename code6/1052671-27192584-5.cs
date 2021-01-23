    public class Word
    {
        public string Text { get; set; }
        public int Counter { get; set; }
        public Word(string text)
        {
            Text = text;
        }
    }
    Word[] words =
    {
        new Word("Hallo"),
        new Word("Flugzeug"),
        new Word("Automobil"),
        new Word("Musikanlage" )
        new Word("Steuerung")
    };
