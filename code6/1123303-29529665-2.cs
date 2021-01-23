    public partial class FoodRegister : Form
    {
    ListManager<Recipe> lm;
    
    public FoodRegister()
    {
       InitializeComponent();
       lm = new ListManager<Recipe>();
    }
    private void UpdateResults()
     {
            ResultListlst.Items.Clear();  //Erase current list
            for (int index = 0; index < lm.Count; index++)
          {  
                Recipe recipe = lm.GetAt(index);
                ResultListlst.Items.Add(recipe.Name + " " + recipe.Ingredient);
          }
     }
    private void Addbtn_Click(object sender, EventArgs e)
     {
            Recipe recept = new Recipe(txtName.Text, txtIngredient.Text);
            lm.Add(recept);          
            UpdateResults();
     }
