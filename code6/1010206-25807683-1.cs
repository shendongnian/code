    public void Randomise(){
        
        for (int i = 0; i < answer.Length; i++) {
            randomNumber = Random.Range (0, 36);
            answer [i].text = randomNumber.ToString ();
        }
        bool anyExist = false;
        for (int j = 0; j < answer.Length; j++)
        {
            if (System.Convert.ToInt32(answer[j].text) % 3 == 0)
            {
                anyExist = true;
                break;
            }
        }
        if (!anyExist)
            Randomise();
    }
