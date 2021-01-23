    void Main()
    {
    	string str = "Example, string";
    	var output = Explain(str);
    	
    	OutputExplanation(output);
    }
    
    private void OutputExplanation(List<LetterExplanation> input)
    {
    	StringBuilder sb = new StringBuilder();
    	
    	foreach(var ltr in input)
    		sb.AppendFormat("The letter {0} is {1}\n", ltr.Letter, ltr.Type);
    	
    	sb.ToString().Dump();
    }
    
    private List<LetterExplanation> Explain(string input) 
    {
    	var sb = new List<LetterExplanation>();
    	
    	foreach(char c in input.ToCharArray())
    	{
    		//c.Dump();	
    		LetterType type = LetterType.Character;
    	
    		// vowel, consonant or special
    		if("aeiou".IndexOf(c.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0)
    			type |= LetterType.Vowel;
    		else if(" ,.-_<>/\\".IndexOf(c.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0)
    			type |= LetterType.Special;
    		else
    			type |= LetterType.Consonant;
    			
    		// uppercase or lowercase
    		if(char.IsUpper(c) && (type & LetterType.Special) != LetterType.Special)
    			type |= LetterType.Uppercase;
    		else if((type & LetterType.Special) != LetterType.Special)
    			type |= LetterType.Lowercase;
    			 
    		// add
    		sb.Add(new LetterExplanation() { Letter = c, Type = type });
    	}
    	
    	return sb;
    } 
    
    [Flags]
    public enum LetterType {
    	Vowel = 1, Consonant = 1 << 1, Uppercase = 1 << 2, Lowercase = 1 << 3, Number = 1 << 4, Special = 1 << 5, Character = 1 << 6
    }
    
    public class LetterExplanation
    {
    	public char Letter { get; set; }
    	public LetterType Type { get; set; }
    }
