    private async void btn_Go_Click(object sender, RoutedEventArgs e)
    {
        HttpClient webClient = new HttpClient();
        Uri uri = new Uri("http://www.school-link.net/webservice/get_student/?id=" + txtVCode.Text);
        HttpResponseMessage response = await webClient.GetAsync(uri);
        var jsonString = await response.Content.ReadAsStringAsync();
        var _Data = JsonConvert.DeserializeObject <List<Student>>(jsonString);
        foreach (Student Student in _Data)
        {
            tb1.Text = Student.student_name;
        }
    }
