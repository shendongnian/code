     // Status Update
            public void UpdateStatus(string eventLevel, string message)
            {
                Paragraph currentStatus = new Paragraph(new Run(message));
                if (eventLevel == "info")
                    currentStatus.Foreground = System.Windows.Media.Brushes.Gray;
                if (eventLevel == "warning")
                    currentStatus.Foreground = System.Windows.Media.Brushes.Yellow;
                if (eventLevel == "error")
                    currentStatus.Foreground = System.Windows.Media.Brushes.Red;
                if (eventLevel == "highlight")
                    currentStatus.Foreground = System.Windows.Media.Brushes.CornflowerBlue;
                currentStatus.LineHeight = 1;
                rtbStatus.Document.Blocks.InsertBefore(rtbStatus.Document.Blocks.FirstBlock, currentStatus);
            }
