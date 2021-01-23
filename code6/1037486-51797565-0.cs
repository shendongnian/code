    I Think I Had Done In Some Different Way I Think You Can Like My Answer
    See My Code:
    Tables
    [Category][1][Products][2]
    
    
    [Sub Category][3]
    
    
      [1]: https://i.stack.imgur.com/Ib6yc.png
      [2]: https://i.stack.imgur.com/HyXap.png
      [3]: https://i.stack.imgur.com/0DVZh.png
    My Aspx code In Nested Repeater
                             <asp:Repeater runat="server" ID="ReptrOuter" OnItemDataBound="ReptrOuter_ItemDataBound" OnItemCommand="ReptrOuter_ItemCommand">
                                            <HeaderTemplate>  
                                           
                                                <ul class="main-navigation js-main-nav"><!--All Opening-->
                                                     <li class="menu-item menu-item-has-children"><a href="Category.aspx">Products</a><!--main Nav closing-->
                                                         <ul class="sub-menu"><!--childerns Opening-->
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                       <li class="menu-item menu-item-has-children"><!--Category open-->
                                                           <asp:LinkButton ID="LBCategory" runat="server" CommandArgument='<%#Eval("CategoryID")%>' Text='<%#Eval("CategoryName")%>'></asp:LinkButton>
    
    
                                                           <asp:Label ID="LBLCategoryID" runat="server" Text='<%#Eval("CategoryID")%>' Visible="false"> </asp:Label>
                                                        
                                                <asp:Repeater ID="ReptrMiddle" runat="server" OnItemDataBound="ReptrMiddle_ItemDataBound" OnItemCommand="ReptrMiddle_ItemCommand">
                                                    <HeaderTemplate>
                                                          <ul class="sub-menu menu-item-has-children"><!--Sub UnlistedCategory open-->
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <li class="menu-item menu-item-has-children"><!--Name Of Sub Category-->
                                                         
                                                            <asp:LinkButton ID="LBSubCategory" runat="server" CommandArgument='<%#Eval("CategoryID")+","+Eval("SubCategoryID")%>' Text='<%#Eval("SubCategoryName")%>' OnClick="LBSubCategory_Click"></asp:LinkButton>
                                                         
                                                           <asp:Label ID="LBLSubCategoryID" runat="server" Text='<%#Eval("SubCategoryID")%>' Visible="false"> </asp:Label>
                                                        <asp:Repeater runat="server" ID="ReptrInner" OnItemCommand="ReptrInner_ItemCommand">
                                                          <HeaderTemplate>
                                                              <ul class="sub-menu">
                                                          </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <li>
                                                                    <asp:LinkButton ID="LBProduct" runat="server" CommandArgument='<%#Eval("CategoryID")+","+Eval("SubCategoryID")+","+Eval("ProductID")%>' Text='<%#Eval("ProductName")%>'></asp:LinkButton>
                                                                    
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </ul>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                            </li>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                             </ul><!--Sub UnlistedCategory Close-->
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                                          
                                                   </li><!--Category Closing-->
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </ul><!--childerns closing-->
                                                </li><!--main Nav closing-->
                                                 </ul><!--All Closing-->
                                            </FooterTemplate>
                                        </asp:Repeater>
    C# Code For All
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    
    namespace JEETANWebApp
    {
        public partial class Site : System.Web.UI.MasterPage
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (IsPostBack)
                {
    
                   // _Product p = new _Product();
                   // _SubCategory sb = new _SubCategory();
                  
                    ////bindProducts();
                   // bindCateory();
                }
                else
                {
                    _Category c = new _Category();
                    bindCateory();
                }
            }
            //    public void bindProducts()
            //    {
            //    using (SqlConnection con = new SqlConnection())
            //    {
            //        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            //        con.Open();
            //        using (SqlCommand cmd = new SqlCommand("USP_Product", con))
            //        {
            //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //            cmd.Parameters.Add("@Action", System.Data.SqlDbType.VarChar).Value = "ReadAll";
            //            using (SqlDataReader dr = cmd.ExecuteReader())
            //            {
            //                if (dr.HasRows)
            //                {
            //                    List<_Product> products = new List<_Product>();
            //                    while (dr.Read())
            //                    {
            //                        _Product p = new _Product();
            //                        p.CategoryID = Convert.ToInt32(dr["CategoryID"]);
            //                        p.SubCategoryID = Convert.ToInt32(dr["SubCategoryID"]);
            //                        p.ProductID = Convert.ToInt32(dr["ProductID"]);
            //                        p.ProductName = Convert.ToString(dr["ProductName"]);
            //                        p.Description = Convert.ToString(dr["Description"]);
            //                        p.DExtension = Convert.ToString(dr["DExtension"]);
            //                        p.IImageID = Convert.ToString(dr["IImageID"]);
            //                        p.DImageID = Convert.ToString(dr["DImageID"]);
            //                        p.IExtension = Convert.ToString(dr["IExtension"]);
            //                        products.Add(p);
            //                    }
            //                   List<_Product> pr = products.OrderBy(ps => ps.ProductID).ToList();
            //                    products = new List<_Product>(pr);
            //                   // LsVwHome.DataSource = products;
            //                   // LsVwHome.DataBind();
                              
            //                }
            //            }
            //        }
            //    }
    
            //}
            public void bindCateory()
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("USP_Category", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Action", System.Data.SqlDbType.VarChar).Value = "ReadAll";
                        SqlDataReader dr = cmd.ExecuteReader();
                        {
                            if (dr.HasRows)
                            {
                                List<_Category> categories = new List<_Category>();
                                while (dr.Read())
                                {
                                    _Category c = new _Category();
                                    c.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                                    c.CategoryName = Convert.ToString(dr["CategoryName"]);
                                    c.Description = Convert.ToString(dr["Description"]);
                                        categories.Add(c);
                                }
                                List<_Category> ct = categories.OrderBy(cis => cis.CategoryID).ToList();
                                categories = new List<_Category>(ct);
                                ReptrOuter.DataSource =categories;
                                ReptrOuter.DataBind();
                                //List<_Product> pr = products.OrderBy(ps => ps.ProductID).ToList();
                                //products = new List<_Product>(pr);
                                // LsVwHome.DataSource = products;
                                // LsVwHome.DataBind();
    
                            }
                        }
                    }
                }
    
            }
            
         
            protected void ReptrOuter_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
    
                
                if(e.Item.ItemType==ListItemType.Item||e.Item.ItemType==ListItemType.Item)
                {
                    Label lb = new Label();
                    lb = e.Item.FindControl("LBLCategoryID") as Label;
                    //int id = Convert.ToInt32(lb.Text);
                    ViewState["CatID"] = Convert.ToInt32(lb.Text);
                    DataRowView drv = e.Item.DataItem as DataRowView;
                    Repeater ReptrMiddle = e.Item.FindControl("ReptrMiddle") as Repeater;
                    using (SqlConnection con = new SqlConnection())
                    {
                        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("USP_SubCategory", con))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Action", System.Data.SqlDbType.VarChar).Value = "SubRead";
                            cmd.Parameters.Add("@CategoryID", System.Data.SqlDbType.Int).Value = ViewState["CatID"];
                            //cmd.Parameters.Add();
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    List<_SubCategory> subCategories = new List<_SubCategory>();
                                    while (dr.Read())
                                    {
                                        _SubCategory SC = new _SubCategory();
                                        SC.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                                        SC.SubCategoryID = Convert.ToInt32(dr["SubCategoryID"]);
                                        SC.SubCategoryName = Convert.ToString(dr["SubCategoryName"]);
                                        subCategories.Add(SC);
                                    }
                                    ReptrMiddle.DataSource = subCategories;
                                    ReptrMiddle.DataBind();
                                }
                            }
                        }
                    }
    
                
                }
            }
    
            protected void ReptrMiddle_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.Item)
                {
                    Label Sublb = new Label();
                    Sublb = e.Item.FindControl("LBLSubCategoryID") as Label;
                    int Subid = Convert.ToInt32(Sublb.Text);
                    DataRowView drv = e.Item.DataItem as DataRowView;
                    Repeater ReptrInner = e.Item.FindControl("ReptrInner") as Repeater;
                    using (SqlConnection con = new SqlConnection())
                    {
                        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("USP_Product", con))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Action", System.Data.SqlDbType.VarChar).Value = "ReadWithCatSubCat";
                            cmd.Parameters.Add("@CategoryID", System.Data.SqlDbType.Int).Value = ViewState["CatID"];
                            cmd.Parameters.Add("@SubCategoryID", System.Data.SqlDbType.Int).Value = Subid;
                            //cmd.Parameters.Add();
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    List<_Product> products = new List<_Product>();
                                    while (dr.Read())
                                    {
                                        _Product product = new _Product();
                                        product.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                                        product.SubCategoryID = Convert.ToInt32(dr["SubCategoryID"]);
                                        product.ProductID = Convert.ToInt32(dr["ProductID"]);
                                        product.ProductName = Convert.ToString(dr["ProductName"]);
                                        products.Add(product);
                                    }
                                    ReptrInner.DataSource = products;
                                    ReptrInner.DataBind();
                                }
                            }
                        }
                    }
    
    
                }
            }
    
            protected void ReptrOuter_ItemCommand(object source, RepeaterCommandEventArgs e)
            {
                Session["CategoryID"] = e.CommandArgument;
                Response.Redirect("SubCategory.aspx");
            }
    
            protected void LBSubCategory_Click(object sender, EventArgs e)
            {
             
            }
    
            protected void ReptrMiddle_ItemCommand(object source, RepeaterCommandEventArgs e)
            {
                string[] values = e.CommandArgument.ToString().Split(new char[] { ',' });
                Session["CategoryID"] = values[0];
                Session["SubCategoryID"] = values[1];
                Response.Redirect("Products.aspx");
            }
    
            protected void ReptrInner_ItemCommand(object source, RepeaterCommandEventArgs e)
            {
    
                string[] values = e.CommandArgument.ToString().Split(new char[] { ',' });
                Session["CategoryID"] = values[0];
                Session["SubCategoryID"] = values[1];
                Session["ProductID"] = values[2];
                Response.Redirect("Product.aspx");
            }
        }
    
        public class _Product
        {
            public int ProductID {get;set;}  
            public string ProductName {get;set;}
            public int SubCategoryID {get;set;}
            public string Description {get;set;}
            public int CategoryID {get;set;}
            public string Drawing { get; set; }
            public string DExtension { get; set; }
            public string IImageID {get;set;}
            public string DImageID { get; set; }
            public string IExtension { get; set; }
        }
        public class _SubCategory
        {
                public int SubCategoryID {get;set;}
                public string SubCategoryName {get;set;}
                public int CategoryID {get;set;}
                public string Description {get;set;}
           
        }
        public class _Category
        {
            public int CategoryID   {get;set;}
            public string CategoryName {get;set;}
            public string Description  {get;set;}
           
        }
    }
    Store Procedures
    USP_Category:
    USE [JEETANVALVEDB]
    GO
    /****** Object:  StoredProcedure [dbo].[USP_Category]    Script Date: 11-Aug-18 1:00:19 PM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    ALTER Procedure [dbo].[USP_Category]
    @Action varchar(30)=null,
    @CategoryID int=null,
    @CategoryName varchar(100)=null,
    @Description  varchar(500)=null,
    @CreatedBy tinyint=null,
    @ModifiedBy  tinyint=null,
    @Image  varchar(50)=null,
    @Extension  varchar(10)=null
    as
    begin
    	if @Action='Create'
    	begin
    		INSERT INTO [dbo].[Category]([CategoryName],[Description],[IsActive],[CreatedBy],
    			[ModifiedBy],[CreatedDate],[ModifiedDate],[Extension])
    		VALUES(@CategoryName,@Description,1,@CreatedBy,null,GETDATE(),null,@Extension);
    		update [dbo].[Category]
    				set [Image]=Concat('C', @@IDENTITY)
    				where dbo.Category.CategoryID=@@IDENTITY;
    				select CONCAT('C',@@IDENTITY) as Message;
    	end
    	if @Action='Read'
    	begin
    		select CategoryID,CategoryName,Description,IsActive,CreatedBy,ModifiedBy,CreatedDate,ModifiedDate from Category where CategoryID=@CategoryID;
    	end
    	if @Action='ReadAll'
    	begin
    		select CategoryID,CategoryName,[Description],IsActive,CreatedBy,ModifiedBy,CreatedDate,ModifiedDate,Image,Extension from Category;
    	end
    	if @Action='Update'
    	begin
    		if @CategoryID is not null
    		begin
    			if @Extension is null
    			begin 
    				UPDATE [dbo].[Category]
    			   SET [CategoryName] = ISNULL(@CategoryName, CategoryName)
    					,[Description] = ISNULL(@Description,[Description])
    					,[ModifiedDate] = GETDATE()
    					,[ModifiedBy] =@ModifiedBy
    					WHERE CategoryID=@CategoryID;
    				select 'Sucess' as Message;
    			end
    			else
    			begin
    				UPDATE [dbo].[Category]
    			   SET [CategoryName] = ISNULL(@CategoryName,CategoryName)
    					,[Description] = ISNULL(@Description,[Description])
    					,[ModifiedDate] = GETDATE()
    					,[ModifiedBy] =@ModifiedBy
    					,[Extension] = @Extension
    					WHERE CategoryID=@CategoryID;
    				SELECT [Image] as Message from Category where CategoryID=@CategoryID;
    			end
    		end
    		else
    		begin
    			select 'Id Is Required' As Message;
    		end
    	end
    end
    USP_SUBCategory
    USE [JEETANVALVEDB]
    GO
    /****** Object:  StoredProcedure [dbo].[USP_SubCategory]    Script Date: 10-Aug-18 6:26:17 PM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    ALTER Procedure [dbo].[USP_SubCategory]
    @Action varchar(30)=null,
    @CategoryID int=null,
    @SubCategoryID int=null
    as
    begin
    	if @Action='ReadAll'
    	begin
    		SELECT SubCategoryID, SubCategoryName, CategoryID, Description,Image,Extension, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate
    		FROM SubCategory ;
    	end
    	if @Action='Read'
    	begin
    		SELECT SubCategoryID, SubCategoryName, CategoryID, Description,Image,Extension, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate
    		FROM SubCategory where SubCategoryID=@SubCategoryID and CategoryID=@CategoryID ;
    	end
    	if @Action='ReadWithCategory'
    	begin
    		SELECT SubCategoryID, SubCategoryName, CategoryID, Description,Image,Extension, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate
    		FROM SubCategory where  CategoryID=@CategoryID ;
    	end
    	if @Action='SubRead'
    	begin
    		SELECT SubCategoryID, SubCategoryName,CategoryID FROM SubCategory where  CategoryID=@CategoryID ;
    	end
    end
    USP_Products:
    USE [JEETANVALVEDB]
    GO
    /****** Object:  StoredProcedure [dbo].[USP_Product ]    Script Date: 10-Aug-18 7:23:00 PM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    -- Batch submitted through debugger: SQLQuery2.sql|7|0|C:\Users\Admin\AppData\Local\Temp\~vs304F.sql
    ALTER Procedure [dbo].[USP_Product ]
    @Action varchar(30)=null,
    @ProductID int=null,
    @ProductName Varchar(100)=null,
    @CategoryID int=null,
    @SubCategoryID int=null,
    @Description varchar(500)=null,
    @IImageID varchar(50)=null,
    @DImageID varchar(50)=null,
    @IExtension varchar(10)=null,
    @DExtension varchar(10)=null,
    @CreatedBy int=null,
    @ModifiedBy int=null,
    @CreatedDate date=null,
    @ModifiedDate date=null
    as
    begin
    	if @Action='Create'
    	begin
    		--begin try
    		--	begin transaction
    				INSERT INTO [dbo].[Product] ([ProductName]
    				,[SubCategoryID],[Description],[CategoryID],[IsActive],[CreatedBy],[ModifiedBy],[CreatedDate]
    				,[ModifiedDate],[IImageID],[IExtension],[DImageID],[DExtension] )VALUES(@ProductName,@SubCategoryID,@Description,@CategoryID,
    				1,@CreatedBy,@ModifiedBy,GETDATE(),null,@IImageID,@IExtension,@DImageID,@DExtension);
    				update [dbo].[Product]
    				set IImageID=@CategoryID+@SubCategoryID+@@IDENTITY
    				where dbo.Product.ProductID=@@IDENTITY;
    				select CONCAT(@CategoryID,@SubCategoryID,@@IDENTITY) as Message;
    		--	commit transaction;
    		--end try
    		--begin catch
    		--	rollback transaction
    		--	select 'Error' as Message;
    		--end catch
    		
    	end	
    	if @Action='Read'
    	begin
    		SELECT [ProductID],[SubCategoryID],[CategoryID],[ProductName],[Description],[CreatedBy]
    		,[ModifiedBy],[CreatedDate],[ModifiedDate],[IImageID],[IExtension],[DImageID],[DExtension]
    		FROM Product where ProductID=@ProductID and SubCategoryID=@SubCategoryID and CategoryID=@CategoryID;
    	end
    	if @Action='ReadAll'
    	begin
    		SELECT [ProductID],[SubCategoryID],[CategoryID],[ProductName],[Description],[CreatedBy]
    		,[ModifiedBy],[CreatedDate],[ModifiedDate],[IImageID],[IExtension],[DImageID],[DExtension]
    		FROM [dbo].[Product];
    	end
    	if @Action='ReadWithCatSubCat'
    	begin
    			SELECT [ProductID],[SubCategoryID],[CategoryID],[ProductName],[Description],[CreatedBy]
    		,[ModifiedBy],[CreatedDate],[ModifiedDate],[IImageID],[IExtension],[DImageID],[DExtension]
    		FROM [dbo].[Product] where SubCategoryID=@SubCategoryID and CategoryID=@CategoryID;
    	end
    	--if @Action='Update' 
    	--begin
    	--	select null;
    	--end
    	if @Action='Delete' 
    	begin
    		select null;
    	end
    	--if @Action='Activate'
    	--begin
    	--	select null;
    	--end
    end
