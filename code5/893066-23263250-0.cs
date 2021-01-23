        string ex = ".xls";
        string FName = "Danh_Sach_Hoc_Sinh";
        FName += ex;
        HtmlForm form = new HtmlForm();
        Literal header = new Literal();
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment; filename=" + FName);
        Response.Charset = "UTF-8";
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        header.Text = "<table><tr><td colspan='6'>Trường: " + Session["TenTruong"].ToString() + "</td><td colspan='2'>Năm học: " + Session["TenNamHoc"].ToString() + "</td></tr> " +
            "<tr><td ALIGN='CENTER' colspan='8'>DANH SÁCH HỌC SINH LỚP.</td></tr>" +
            "<tr><td colspan='8'>" + ((cb_Khoi.SelectedValue == "" && cb_Lop.SelectedValue == "") ? "Toàn trường" : ((cb_Khoi.SelectedValue != "" && cb_Lop.SelectedValue == "") ? "Toàn khối " + cb_Khoi.SelectedValue : "Lớp: " + cb_Lop.SelectedItem.Text + " - Giáo viên: " + db.Rows[0]["GiaoVien"].ToString())) + "</td></tr>" +
            "</table>";
        form.Attributes["runat"] = "server";
        form.Controls.Add(header);
        form.Controls.Add(gv_dshocsinh);
        Controls.Add(form);
        form.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
