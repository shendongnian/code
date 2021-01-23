    	public class ReverseString
	{
		public ReverseString ()
		{
			Task.Run (async () => {
				//helper function is the post function for the webrequest
				var helper = new Helper ();
				Session.Instance.SetToken (JsonConvert.DeserializeObject<Response> (
					await helper.Post ("http://challenge.code2040.org/api/getstring", 
						JsonConvert.SerializeObject (new { token = "Y6C15DVN99" 
							 }))).Result);
			});
			Console.WriteLine (alorgorithmForReversingString.reverser (Session.Instance.Token));
		}
	}
}
