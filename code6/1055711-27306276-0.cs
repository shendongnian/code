    public class DTOProductAttachment
    {
        Product Product { get; set; }
        List<Attachment> Attachments { get; set; }
    
        public DTOProductAttachment(int id, string name)  // <-- Product ID, Product Name
        { 
            Product = ProductRepository.GetProduct(id); // <-- Product ID
            Attachments = AttachmentRepository.GetAttachmentsByProductName(name); // <-- Product Name, or ID or whatever joins your tables
        }; 
    }
