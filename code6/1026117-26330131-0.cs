    public partial class Form1 : Form
    {
        Recepie pancakes = new Recepie();
        IList<UniqueHolder> items = new List<UniqueHolder>();
        public Form1()
        {
            InitializeComponent();
            pancakes.Ingredients.Add(new Ingredient { Title = "Milk - 250 gr" });
            pancakes.Ingredients.Add(new Ingredient { Title = "Butter - 25 gr" });
            pancakes.Ingredients.Add(new Ingredient { Title = "Oil - 1 large spoon" });
            pancakes.Ingredients.Add(new Ingredient { Title = "Sugar - 100 gr" });
            pancakes.Ingredients.Add(new Ingredient { Title = "Flower - 200 gr" });
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < pancakes.Ingredients.Count; i++)
            {
                Ingredient ing = pancakes.Ingredients[i];
                TextBox tb = new TextBox { Location = new Point(10, i * 30), Size = new Size(200, 20), Text = ing.Title };
                UniqueHolder uh = new UniqueHolder { Ingredient = ing, TextBox = tb };
                this.Controls.Add(tb);
            }
        }
    }
