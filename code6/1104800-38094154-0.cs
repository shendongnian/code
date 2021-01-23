    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    public class Testing : MonoBehaviour {
        public string CurrentQuestion;
        public ArrayList Answers = new ArrayList();
    
        public Button QuestionButton;
        public GameObject QuestionUI;
        public Text QuestionText;
    
        void Start(){
        	StartCoroutine(PresentQuestion());
        }
    
        IEnumerator PresentQuestion(){
        	CurrentQuestion = "How many times do we have to do this to make it work?";
        	Answers.Add ("1");
        	Answers.Add ("2");
        	Answers.Add ("3");
        	Answers.Add ("4");
    	
        	float newY = 80.0f;
        	foreach(string answer in Answers){
        		newY-=65.0f;
        		Button btn = Instantiate(QuestionButton);
    	    	btn.transform.position = new Vector3(225, newY, 0);
    		    btn.transform.SetParent(QuestionUI.transform, false);
        		btn.gameObject.SetActive(true);
        		btn.transform.FindChild("Text").GetComponent<Text>().text = locanswer;
    	    	SetButtonOnClick(btn, answer);
        	}
        	QuestionText.text = CurrentQuestion;
    
    	    return null;
        }
    
        void SetButtonOnClickAnswer(Button button, string value){
            button.onClick.AddListener(() => AnswerClicked(value));
        }
        void AnswerClicked(string value){
    	    print (value);
        }
    }
