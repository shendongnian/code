    // This list is to keep track of which letters are vowels
    var vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
    // This is the word we want to check the order of
    string word = "testing"; // gives true
    // We start of by finding all vowels in the word (in the order they appear)
    var vowelList = word.Where(letter => vowels.Any(v => letter == v));
    // We create a list that looks like we expect it to if its correct order
    var expectedResult = vowelList.OrderBy(x => x);
    // We check if we have a result in the expected order
    bool isOrdered = vowelList.SequenceEqual(expectedResult);
