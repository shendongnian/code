    void encrypt()
    {
    string encrypted = "";
    string encryptstr = yourtextBox.Text;
    int encryptnum = 15; //The bigger the number, the stronger the encryption
    char[] toencrypt = encryptstr.ToCharArray();
    for (int i = 0; i < toencrypt.Length; i++)
    int num = Convert.ToInt32(toencrypt[i]) + encryptnum;
    string out = Convert.ToChar(num).ToString();
    encrypted += out;
    }
   
    void decrypt() 
    {
    string decrypted = "";
    string decryptstr = yourtextBox.Text;
    int decryptnum = 15; //This must be the same as you used to encrypt
    char[] todecrypt = decryptstr.ToCharArray();
    for (int i = 0; i < todecrypt.Length; i++)
    int num = Convert.ToInt32(todecrypt[i]) - decryptnum;
    string out = Convert.ToChar(num).ToString();
    decrypted += out;
    }
