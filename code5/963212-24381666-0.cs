    abstract class DocumentSender   //Base class for all document sending components
    {
        public abstract bool CanSend(Case @case);        // Check if sender can send the document
        public abstract void SendDocument(Case @case);   // Send the document
    }
    class DefaultDocumentSender : DocumentSender
    {
        public override bool CanSend(Case @case)
        {
            return true;   //Can process all requests
        }
        public override void SendDocument(Case @case)
        {
           // Do something
        }
    }
    class Customer123DocumentSender : DocumentSender
    {
        public override bool CanSend(Case @case)
        {
            return @case.Type == 1 || @case.Type == 2;   //Specific case
        }
        public override void SendDocument(Case @case)
        {
            // Do something different
        }
    }
    //Separate class for getting the correct sender
    class CaseSenderFactory    
    {
        readonly List<DocumentSender> _senders = new List<DocumentSender>();
        public DocumentSenderFactory()
        {
            //Initialize the list of senders from the most specific. 
            _senders.Add(new Customer123DocumentSender());
            // Add more specific cases here
            _senders.Add(new DefaultDocumentSender());   //Last item should be the default sender
        }
        public DocumentSender GetDocumentSender(Case @case)
        {
            //At least one sender needs to satisfy the condition
            return _senders.First(x => x.CanSend(@case));   
        }
    }
