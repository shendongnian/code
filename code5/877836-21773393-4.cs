        public int TempoInteger {
          get {
            double result;
        
            if (TryGetValue(out result, 
              s => s > 0.0d, 
              s => s.TempoBass, 
              s => s.AudioSummary != null ? s.AudioSummary.Tempo : 0.0d)) 
            {
              return (int)Math.Round(result);
            }
            return -1;
          }
        }
