    SqlConnection my_cn = new SqlConnection("Data Source=NIMA-PC;Initial Catalog=PDFha;Integrated Security=True");
    my_cn.Open();
    SqlCommand cmd = new SqlCommand("SELECT Books.Name,Books.Subject,Books.PublisherName,Books.Summery FROM Books WHERE (Books.Subject= '" + subList.SelectedValue.ToString() + "') AND (Books.Name= '" + searchName.Text + "')", my_cn);
    SqlDataAdapter adapter = new SqlDataAdapter();
    adapter.SelectCommand = cmd;
    adapter.Fill(ds);
    DataTable dt = ds.Tables[0];
    //Modified start
    //You don't need SQLReader, While loop
    GridView1.DataSource = dt;
    GridView1.DataBind();
    //Modified End
    my_cn.Close();
