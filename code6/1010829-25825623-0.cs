    Console.WriteLine("Enter The Length Of Linear Array");
    int length = Convert.ToInt32(Console.ReadLine());
    int[] LinearArr = new int[length + 2];
    Console.WriteLine("Maximum Number Of Inputs : {0}", length);
    
    
    for (int i = 1; i < LinearArr.Length - 1; i++)
    {
        LinearArr[i] = Convert.ToInt32(Console.ReadLine());
    }
    Console.WriteLine("What Number You Want To Delete And At What Index");
    int InsertNum2 = Convert.ToInt32(Console.ReadLine());
    int k2 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Number :{0} And Index :{1}",InsertNum2,k2);
    
    //create a new array with length = LinearArray - 1
    int[] newArray = new int[LinearArray.Length - 1];
    int currentIndex = 0;
    
    InsertNum2 = LinearArr[k2];
    for (int i = 0; i < LinearArr.Length; i++)
    {
        //if i == index want to delete, ignore
        if(i != k2) 
        {
            newArray[currentIndex] = LinearArray[i];
            currentIndex++;
        }
    }
    length = length - 1;
    for (int i = 0; i < newArray.Length-1; i++)
    {
        Console.WriteLine(newArray[i]);
    }
