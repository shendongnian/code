        awDushiHomesClients OpenawViewClients;
        private void ViewClientsMenuB_Click(object sender, EventArgs e)
        {
            if (OpenawViewClients == null)
            {
                OpenawViewClients = new awDushiHomesClients();
                OpenawViewClients.MdiParent = this;
                OpenawViewClients.FormClosed += OpenawViewClients_FormClosed;
                OpenawViewClients.Show();
            }
            else
                OpenawViewClients.Activate();
        }
        void OpenawViewClients_FormClosed(object sender, FormClosedEventArgs e)
        {
            OpenawViewClients = null;
            ///throw new NotImplementedException();
        }
