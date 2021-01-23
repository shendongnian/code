    public class Invoice{
         ISet<Line> _lines;
         public void ChangeLineAmount(int LineId, double newAmount)
         {
            var line = _lines.FirstOrDefault(l=>l.LineId == LineId);
            if (line != null)
            {
                line.Amount = newAmount;
            }
         }
    }
