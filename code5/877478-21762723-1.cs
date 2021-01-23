    public class Rule {
        public Func<string, bool> Predicate { get; set; }
        public string Description { get; set; }
    }
    private List<Rule> rules = new List<Rule>() {
        new Rule(){ Predicate = (s => s != null),
          Description = "Password must not be null" },
        new Rule(){ Predicate = (s => s.Length >= kMinimumLength ),
          Description = "Password must have at least " + kMinimumLength + " characters." },
        new Rule(){ Predicate = (s => s.Count(c => IsSpecialChar(c)) >= 1),
          Description = "Password must contain at least one of " + _specialChars },
        new Rule(){ Predicate = (s => !IsSpecialChar(s[0]) && !IsSpecialChar(s[s.Length - 1])),
          Description = "Password must not start or end with " + _specialChars },
        new Rule(){ Predicate = (s => s.Count(c => Char.IsLetter(c)) > 0),
          Description = "Password must contain at least one letter." },
        new Rule(){ Predicate = (s => s.Count(c => Char.IsDigit(c)) > 0),
          Description = "Password must contain at least one digit." },
        new Rule(){ Predicate = (s =>s.Count(c => !IsValidPasswordChar(c)) == 0),
          Description = "Password must contain letters, digits, or one of " + _specialChars }
    }
    public bool IsPasswordValid(string s, ref string failureReason)
    {
        foreach (Rule r in rules) {
            if (!r.Predicate(s)) {
              failureReason = r.Description;
              return false;
            }
        }
        return true;
    }
