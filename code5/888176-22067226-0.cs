        private string BuildMessageBody()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<html>");
            builder.Append("<body>");
            
            // Custom HTML code could go here (I.e. a HTML table).
            builder.Append(TextBox1.Text); // Append the textbox value
            builder.Append("</body>");
            builder.Append("</html>");
            return builder.ToString();
        }
