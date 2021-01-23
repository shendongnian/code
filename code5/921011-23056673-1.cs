    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Documents;
    
    namespace ComboBoxDGWPF
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
    
                List<TicketInfo> ticketsList = new List<TicketInfo> 
                {
                    new TicketInfo{ Status="Open"},
                    new TicketInfo{ Status="Assigned"},
                    new TicketInfo{ Status="Open"},
                    new TicketInfo{ Status="Open"},
                    new TicketInfo{ Status="Closed"},
                    new TicketInfo{ Status="Open"},
                    new TicketInfo{ Status="Open"}
                };
                dgData.ItemsSource = ticketsList;
            }
        }
    
        public class TicketInfo
        {
            public string Status { get; set; }
        }
    
        public class StatusList : List<string>
        {
            public StatusList()
            {
                this.Add("Assigned");
                this.Add("Closed");
                this.Add("In Progress");
                this.Add("Open");
                this.Add("Resolved");
            }
        }
    }
