    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Exchange;
    using Microsoft.Exchange.WebServices;
    using Microsoft.Exchange.WebServices.Data;
    using System.Threading;
    namespace DownloadAttachmentExchange
    {
    class ExchangeDwnClass
    {
        private string path_ = "";
        private string filterSender_ = "";
        private string subject_ = "";
        private string id_ = "";
        private string username_ = "";
        private string password_ = "";
        private string exchange_ = "";
        private string filterExcel_ = "";
        private string filterCSV_ = "";
        private string attachmentName_ = "";
        private int emailFetch_ = 0;
        private DateTime current_;
        ExchangeService serv = new ExchangeService(ExchangeVersion.Exchange2010_SP1);
        
        public string Path
        {
            get { return path_; }
            set { path_ = value; }
        }
        public string FilterSender
        {
            get { return filterSender_; }
            set { filterSender_ = value; }
        }
        public string Subject
        {
            get { return subject_; }
            set { subject_ = value; }
        }
        public string ID
        {
            get { return id_; }
            set { id_ = value; }
        }
        public string Username
        {
            get { return username_; }
            set { username_ = value; }
        }
        public string Password
        {
            get { return password_; }
            set { password_ = value; }
        }
        public string Exchange
        {
            get { return exchange_; }
            set { exchange_ = value; }
        }
        public string FilterExcel
        {
            get { return filterExcel_; }
            set { filterExcel_ = value; }    
        }
        public string FilterCsv
        {
            get { return filterCSV_; }
            set { filterCSV_ = value; }
        }
        public string AttachementName
        {
            get { return attachmentName_; }
            set { attachmentName_ = value; }
        }
        public int EmailFetch
        {
            get { return emailFetch_; }
            set { emailFetch_ = value; }
        }
        public DateTime CurrentDate
        {
            get { return current_; }
            set { current_ = value; }
        }
        
        public void GetAttachments(Form1 form)
        {
            try
            {  
                serv.Credentials = new WebCredentials(Username, Password);
                serv.AutodiscoverUrl("username@domain.lan");
                ItemView view = new ItemView(EmailFetch);
                FindItemsResults<Item> result = serv.FindItems(WellKnownFolderName.Inbox, new ItemView(EmailFetch));
                if (result != null && result.Items != null && result.Items.Count > 0)
                {
                    foreach (Item item in result.Items)
                    {
                        EmailMessage msg = EmailMessage.Bind(serv, item.Id, new PropertySet(BasePropertySet.IdOnly, ItemSchema.Attachments, ItemSchema.HasAttachments, EmailMessageSchema.From, EmailMessageSchema.Sender));
                        if (msg.Sender.ToString().ToLower().Contains(FilterSender) && msg.From.ToString().ToLower().Contains(FilterSender))
                        {
                            foreach (Attachment att in msg.Attachments)
                            {
                                if (att is FileAttachment)
                                {
                                    FileAttachment file = att as FileAttachment;
                                    if (file.Name.Contains(FilterExcel) || file.Name.Contains(FilterCsv))
                                    {
                                        file.Load(Path +"\\"+ file.Name);
                                        form.attachment = file.Name.ToString();
                                        form.subject = item.Subject.ToString();
                                        //ID = item.Id.ToString();
                                        form.date = DateTime.Now.ToString();
                                        form.sender = msg.Sender.ToString();
                                        form.backgroundWorker1.ReportProgress(0);
                                        Thread.Sleep(60000);
                                    }
                                }
                            }
                        }
                        //item.Delete(DeleteMode.HardDelete);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
        public void StopDownloadingAttachment()
        { 
            
        }
    }
    }
