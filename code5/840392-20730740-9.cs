    private void btnToevoegR_Click(object sender, EventArgs e)
    {
         Forms.HandAddReserveer HAR = new Forms.HandAddReserveer();
         HAR.ReservationComplete += Har_ReservationComplete;
         HAR.Show();
    }
    
    private void Har_ReservationComplete(Object sender, EventArgs e) {
         DataTable DT = DBReserveer.getAllReserveerItems();
         gvUitleen.DataSource = DT;
    }
