    private void CreateNewEnemyTab()
    {
        var newTabPage = new TabPage()
        {
            Text = "Enemy " + enemyNumber,
        };
        EnemyTabUserControl enemyTab = new EnemyTabUserControl(enemyNumber);
        here the EnemyTabUserControl should have all the components you need;
        newTabPage.Controls.Add(enemyTab);
        tabControl1.TabPages.Add(newTabPage);
    }
