    DateTime dt = DateTime.Now;               //Gets the current date
    string datetime = dt.ToString();          //converts the datetime value to string
    string[] DateTime = datetime.Split(' ');  //splitting the date from time with the help of space delimeter
    string Date = DateTime[0];                //saving the date value from the string array
    string Time = DateTime[1];                //saving the time value
    **NOTE:** The value of the index position will vary depending on how the DateTime 
    value is stored on your server or in your database if you're fetching from one.
    Output: 10/16/2019 1:38:24 PM
            10/16/2019 1:38:24 PM
            ["10/16/2019","1:38:24","PM"]
            10/16/2019
            1:38:24
