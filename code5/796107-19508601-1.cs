    using System.Linq;
    ...
    var test = "na\u0308ive"; // want to count ä as one character
    var categoriesNotToCount = new []
    { 
        UnicodeCategory.EnclosingMark,
        UnicodeCategory.NonSpacingMark, 
        UnicodeCategory.SpacingCombiningMark 
    };
    var length = test
        .Count(c => 
            !categoriesNotToCount.Contains(Char.GetUnicodeCategory(c)) // we just happen to know that all the code points in categoriesNotToCount are representable by one UTF-16 code unit
            & !Char.IsHighSurrogate(c) // don't count the high surrogate because we're already counting the low surrogate 
        );
