    string[] rand_word = {apple, bannnana, cat, dog, eatttt}//5 words to check with the dictionary. Amount of words in here can vary later, that's why I am using a loop bellow
    string likelihood = 0;
    List<Thread> threads = new List<Thread>();
    foreach (string line in rand_word)
    {        
        Thread thread1 = new Thread(new ThreadStart(() => dictionary_match(line, ref likelihood)));
        thread1.Start();
        threads.Add(thread1);
        Console.WriteLine("Value of likelihood Inside the Loop= " + likelihood); //Will show 0 since the dictionary_match function isn't finished running
    }
    Console.WriteLine("Value of likelihood after the Loop= " + likelihood);//Will give 0 since the dictionary_match function isn't finished
    
    foreach (var thread in threads)
    {
        thread.Join();
    }
    
    Console.WriteLine("Final Value likelihood = " + likelihood); //After pausing for a while, dictionary_match function finished processing and gives an appropriate value for likelihood variable
