In order to prevent the NullPointerException, it was necessary to review the [DataContract] and [DataMember] attributes. interface IFlashcard needs no contract at all:
    interface IFlashcard
    {
        string Question { get; set;  }
        string Answer { get; set; }
    }
The code for class Flashcard remains unchanged, just as I wrote it in the description. The only real change necessary was to *remove* the `[DataMember]`attributes from  `Question` and `Answer` in `class FlippedFlashcard`, like this:
    [DataContract]
    class FlippedFlashcard : IFlashcard
    {
        [DataMember]
        public Flashcard OriginalFlashcard { get; set; }
        public string Question
        {
            get { return OriginalFlashcard.Answer; }
            set { OriginalFlashcard.Answer = value; }
        }
        public string Answer
        {
            get { return OriginalFlashcard.Question; }
            set { OriginalFlashcard.Question = value; }
        }
    }
