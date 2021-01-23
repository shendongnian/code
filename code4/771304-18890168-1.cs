    string pattern = @"(?>(\p{P})\1+)(?<!([^.]|^)\.{3})";
    //Your examples:
    Assert.IsTrue( Regex.IsMatch( @";;", pattern ) );
    Assert.IsTrue( Regex.IsMatch( @",,", pattern ) );
    Assert.IsTrue( Regex.IsMatch( @"\\", pattern ) );
    //two and four dots should match
    Assert.IsTrue( Regex.IsMatch( @"..", pattern ) );
    Assert.IsTrue( Regex.IsMatch( @"....", pattern ) );
            
    //Some success variations
    Assert.IsTrue( Regex.IsMatch( @".;;", pattern ) );
    Assert.IsTrue( Regex.IsMatch( @";;.", pattern ) );
    Assert.IsTrue( Regex.IsMatch( @";;///", pattern ) );            
    Assert.IsTrue( Regex.IsMatch( @";;;...//", pattern ) ); //If you use Regex.Matches the matches contains ;;; and // but not ...
    Assert.IsTrue( Regex.IsMatch( @"...;;;//", pattern ) ); //If you use Regex.Matches the matches contains ;;; and // but not ...            
    //Three dots should not match
    Assert.IsFalse( Regex.IsMatch( @"...", pattern ) );
    Assert.IsFalse( Regex.IsMatch( @"a...", pattern ) );
    Assert.IsFalse( Regex.IsMatch( @";...;", pattern ) );                        
            
    //Other tests
    Assert.IsFalse( Regex.IsMatch( @".", pattern ) );
    Assert.IsFalse( Regex.IsMatch( @";,;,;,;,", pattern ) );  //single punctuation does not match                        
    Assert.IsTrue( Regex.IsMatch( @".;;.", pattern ) );
    Assert.IsTrue( Regex.IsMatch( @"......", pattern ) );                                       
    Assert.IsTrue( Regex.IsMatch( @"a....a", pattern ) );
    Assert.IsFalse( Regex.IsMatch( @"abcde", pattern ) );     
