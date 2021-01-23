    public class MyButtonScript : MonoBehaviour {
        public void Setup(/* Some parameters */){
            // Do some setting up
            UISprite sprite = GetComponent<UISprite>();
            sprite.spriteName = "someSpriteBasedOnTheParametersPassed";
        }
        void OnClick(){
            // Do something when this button is clicked based on how we set this button up
        }
    }
