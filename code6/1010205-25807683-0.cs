    public void Randomise(){
        
        for (int i = 0; i < answer.Length; i++) {
            randomNumber = Random.Range (0, 36);
            answer [i].text = randomNumber.ToString ();
        }
        if (!(Answer.Any(p => (Convert.ToInt32(p)) % 3 == 0)))
            Randomise();
    }
