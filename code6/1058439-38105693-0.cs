    Inspectors allInspectors;
            
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
               
                allInspectors = Globals.ThisAddIn.Application.Inspectors;
                allInspectors.NewInspector += new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);
                
            }
    
    
            void Inspectors_NewInspector(Microsoft.Office.Interop.Outlook.Inspector Inspector)
            {
                if (Inspector.CurrentItem is Outlook.MailItem)
                {
                    mailItem.Open += new ItemEvents_10_OpenEventHandler(MailItemOpen);
                   
                }
            }
            public void MailItemOpen(ref bool Cancel)
            {
                var mailItem = Globals.ThisAddIn.Application.ActiveInspector().CurrentItem as Outlook.MailItem;
                string text = mailItem.HTMLBody;
            }
