            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(String.Format("{0}\t\t: {1}", "Systolic", 80));
            stringBuilder.AppendLine(String.Format("{0}\t\t: {1}", "Diastolic", 170));
            stringBuilder.AppendLine(String.Format("{0}\t\t: {1}", "Pulse", 50));
            stringBuilder.AppendLine(String.Format("{0}\t: {1}", "LooooooongDesc", 50));
            this.tb.Text = stringBuilder.ToString();
