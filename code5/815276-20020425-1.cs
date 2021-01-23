    string[] rand_word = {apple, bannnana, cat, dog, eatttt}//5 words to check with the dictionary. Amount of words in here can vary later, that's why I am using a loop bellow
    string likelihood = 0;
    var tasks = new List<Task>();
    foreach (string line in rand_word)
    {        
        tasks.Add(Task.Factory.StartNew(() =>
             { 
                  dictionary_match(line, ref likelihood)));
                   Console.WriteLine("Value of likelihood Inside the Loop= " 
                                                             + likelihood); 
             });
    }
    Console.WriteLine("Value of likelihood after the Loop= " + likelihood)
    Task.WaitAll(tasks);
    Console.WriteLine("Final Value likelihood = " + likelihood);
