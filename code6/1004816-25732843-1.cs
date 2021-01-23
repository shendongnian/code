    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    using System.Web.Script.Serialization;
    using MvcApplication1.Models;
    using System.Data.Objects.SqlClient;
    using System.Data;
    
    namespace MvcApplication1.Controllers
    {
        public class HomeController : Controller
        {
            ProductEditViewModel vm = new ProductEditViewModel();
    
            // sample for populate sql server database table via entity framework
            // 1. Install EntityFramework 5.0, if previous sample for using populate oracle database table via entity framework has been installed, this can be skiped : execute command at Package Manager Console "Install-Package EntityFramework -Version 5.0.0" ( Oracle data access provider ODAC 12.1.0.1.2 current is not support (work with) EntityFramework version 6 ). If you want uninstall EntityFramework 5, using command "unInstall-Package EntityFramework -Version 5.0.0"
            // 2. Models => Add => New item => Data => Ado.Net Entity Data Model ( using EntityFramework 5.0 )
            public ActionResult ProductList()
            {
                var northwind = new NorthwindEntities(); // 3. this is connectionStrings name="NorthwindEntities"
    
                var q = from pro in northwind.Products
                        select new ProductListViewModel
                        {
                            ProductId = pro.ProductID,
                            ProductName = pro.ProductName,
                            Supplier = pro.Supplier.CompanyName,
                            Categorie = pro.Category.CategoryName,
                            Discontinued = pro.Discontinued,
                            UnitPrice = pro.UnitPrice
                        };
    
                return View(q.ToList());
            }
    
            [HttpGet]
            public ActionResult ProductEdit(Int32 ProductId)
            {
                vm.Product = vm.repository.GetProductById(ProductId);
                return View(vm);
            }
    
            [HttpPost]
            public ActionResult ProductEdit(Int32 ProductId, FormCollection fc)
             {
                vm.Product = vm.repository.GetProductById(ProductId);
                UpdateModel(vm.Product, "Product");
                vm.repository.Save();
                return RedirectToAction("ProductList");
            }
        }
    }
------------------------
    @model MvcApplication1.Models.ProductEditViewModel
    
    @{
        Layout = null;
    }
    
    <script type="text/javascript">
    
    </script>
    
    <!DOCTYPE html>
    
    <html>
    <head>
        <meta name="viewport" content="width=device-width" />
        <title>ProductEdit</title>
    </head>
    <body>
        <script src="~/Scripts/jquery-1.10.2.min.js"></script>
        <script src="~/Scripts/jquery.validate.min.js"></script>
        <script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>
    
    
        @using (Html.BeginForm())
        {
            @Html.AntiForgeryToken()
    
            <div class="form-horizontal">
                <h4>Product</h4>
                <hr />
                @Html.ValidationSummary(true, "", new { @class = "text-danger" })
                @Html.HiddenFor(model => model.Product.ProductID)
    
                <div class="form-group">
                    @Html.LabelFor(model => model.Product.ProductName, htmlAttributes: new { @class = "control-label col-md-2" })
                    <div class="col-md-10">
                        @Html.EditorFor(model => model.Product.ProductName, new { htmlAttributes = new { @class = "form-control" } })
                        @Html.ValidationMessageFor(model => model.Product.ProductName, "", new { @class = "text-danger" })
                    </div>
                </div>
    
                <div class="form-group">
                    @Html.LabelFor(model => model.Product.SupplierID, "SupplierID", htmlAttributes: new { @class = "control-label col-md-2" })
                    <div class="col-md-10">
                        @*DropDownList is for deiplay purpose*@
                        @*@Html.DropDownList("SupplierID", Model.SupplierItems, htmlAttributes: new { @class = "form-control" })*@
    
                        @*DropDownListFor is for Edit purpose*@
                        @Html.DropDownListFor(model => model.Product.SupplierID, Model.SupplierItems, htmlAttributes: new { @class = "form-control" })
                    </div>
                </div>
    
                <div class="form-group">
                    @Html.LabelFor(model => model.Product.CategoryID, "CategoryID", htmlAttributes: new { @class = "control-label col-md-2" })
                    <div class="col-md-10">
                        @*RadioButton is for Display purpose*@
                        @*@foreach (var Categorie in Model.CategorieItems)
                            {
                                @Html.RadioButton("CategoryID", Categorie.CategoryID, Model.CategorySelectedId == Categorie.CategoryID) @Categorie.CategoryName; @:&nbsp;&nbsp;&nbsp;
                            }*@
    
                        @*RadioButtonFor is for Edit purpose*@
                        @foreach (var Categorie in Model.CategorieItems)
                        {
                            @Html.RadioButtonFor(model => model.Product.CategoryID, Categorie.CategoryID) @Categorie.CategoryName; @:&nbsp;&nbsp;&nbsp;
                        }
    
                    </div>
                </div>
    
                <div class="form-group">
                    @Html.LabelFor(model => model.Product.UnitPrice, htmlAttributes: new { @class = "control-label col-md-2" })
                    <div class="col-md-10">
                        @Html.EditorFor(model => model.Product.UnitPrice, new { htmlAttributes = new { @class = "form-control" } })
                        @Html.ValidationMessageFor(model => model.Product.UnitPrice, "", new { @class = "text-danger" })
                    </div>
                </div>
    
                <div class="form-group">
                    @Html.LabelFor(model => model.Product.Discontinued, htmlAttributes: new { @class = "control-label col-md-2" })
                    <div class="col-md-10">
                        <div class="checkbox">
                            @Html.EditorFor(model => model.Product.Discontinued)
                            @Html.ValidationMessageFor(model => model.Product.Discontinued, "", new { @class = "text-danger" })
                        </div>
                    </div>
                </div>
    
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <input type="submit" value="Save" class="btn btn-default" />
                    </div>
                </div>
            </div>
        }
    
        <div>
            @Html.ActionLink("Back to List", "Index")
        </div>
    </body>
    </html>
