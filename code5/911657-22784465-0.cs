    int guessTheNumber = Convert.ToInt32(txtNumberGuess.Text);
    DialogResult dialogResult;
    ArrayList numberList = new ArrayList();
    for(int i=1; i<10; i++)
       numberList.Add(i);
    int length = index.Count;
    do
    {
       Random newNumberGenerator = new Random();
       index = newNumberGenerator.Next(length);
       dialogResult = MessageBox.Show("Is number" + numberList[index].ToString() + " you are thinking about?", "Answer the question!", MessageBoxButtons.YesNo);
       if( dialogResult == DialogResult.No) 
       {
          numberList.RemoveAt(index);
          length = length - 1;
          if(length == 0)
          {
              MessageBox.Show("No number left!!");  
              return;
          }
       }
    }while (dialogResult == DialogResult.No);
    MessageBox.Show("Congratulation! You guessed the number!!");
