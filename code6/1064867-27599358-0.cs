    public class ExampleClass : MonoBehaviour {
    public string url = "File download URL here";
    IEnumerator Start() {
        WWW www = new WWW(url);
        yield return www;
        //retreive the file content using www.text
        //write your code here
    }
