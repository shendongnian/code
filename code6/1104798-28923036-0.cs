    // Use this for initialization
	void Start () {
		QuestionUI.SetActive (false);
		StartCoroutine(PresentQuestion ());
	}
	IEnumerator PresentQuestion(){
		CurrentStage = Stage.QuestionStart;
		CurrentQuestionCard = Instantiate (QuestionCard);
		CurrentQuestionCard.GetComponent<QuestionCard> ().MoveCardToPosition (QuestionSlot);
		yield return new WaitForSeconds(3);
		ShowQuestion ();
	}
	void ShowQuestion(){
		QuestionUI.SetActive (true);
		QuestionUI.SetActive (true);
		CurrentQuestion = "How many times do we have to do this to make it work?";
		Answers.Add ("1");
		Answers.Add ("2");
		Answers.Add ("3");
		Answers.Add ("4");
		
		float newY = 80.0f;
		foreach(string answer in Answers){
			newY-=65.0f;
			string locanswer = answer;
			Button btn = Instantiate(QuestionButton);
			btn.transform.position = new Vector3(225, newY, 0);
			btn.transform.SetParent(QuestionUI.transform, false);
			btn.gameObject.SetActive(true);
			btn.transform.FindChild("Text").GetComponent<Text>().text = locanswer;
			btn.onClick.AddListener(() => AnswerClicked(locanswer));
		}
		QuestionText.text = CurrentQuestion;
	}
	void AnswerClicked(string value){
		print (value);
    }
