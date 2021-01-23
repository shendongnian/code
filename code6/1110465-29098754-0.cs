    public class state : List<situation> {
    
        public override bool Equals(object obj) {
            state s = obj as state;
            if (s != null) {
                foreach (situation situation in s) {
                    if (!this.Contains(situation)) { return false; }
                }
    
                foreach (situation situation in this) {
                    if (!s.Contains(situation)) { return false; }
                }
    
                return true;
            }
            return false;
        }
    }
