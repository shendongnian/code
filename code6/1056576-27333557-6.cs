    public class Player
    {
     public int money;
     public void setMoney(int amount)
     {
      money = amount;
     }
    }
    Player Player1;
    public void init()
    {
     Player1 = new Player();
    }
    
    public void main()
    {
     Player1.Money = 9001;
    }
    
    private void mainForm_Load(object sender, EventArgs e)
    {
     init();
     main();
    }
