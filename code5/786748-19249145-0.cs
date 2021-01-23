    var Liste1 = _db.T_Subscribers.Where(x => x.firstname.StartsWith(search));
    var Liste2 = Liste1.Except(
                   _selectedcourse.T_Coursedetail.Select(b => b.T_Subscribers));
    var Liste3 = Liste2.Where(M =>
                    M.T_Tln_Student == null ||
                    M.T_Tln_Stud.Status.T_Status.T_Statusart == _studentEx);
    var Liste = Liste3.ToList();
