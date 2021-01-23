    @model BarClients.Models.BarClientsViewModel
    @{
        WebGrid grid = null;
        if (Model.EmailAddressesOfChosenClient.Count<string>() != 0)
        {
            grid = new WebGrid(Model.EmailAddressesOfChosenClient, ajaxUpdateContainerId: "gridContent");
        }
    }
    <div id="gridContent">
    @{ if (grid != null)
       {
           <table>
               <tr>
                   <td>
                       @grid.GetHtml(
                tableStyle: "webgrid-table",
                headerStyle: "webgrid-header",
                footerStyle: "webgrid-footer",
                alternatingRowStyle: "webgrid-alternating-row",
                selectedRowStyle: "webgrid-selected-row",
                rowStyle: "webgrid-row-style",
                mode: WebGridPagerModes.All,
                columns: grid.Columns(
                grid.Column("Email Addresses", format: item => item)))
                   </td>
                   <td valign="top">
                       @Html.DisplayFor(model => model.InvoiceMode)
                   </td>
               </tr>
           </table>
      
          <br />
          <table>
              <tr>
                  <th align="left">
                      @Html.TextBoxFor(model => model.NewEmailAddress)
                  </th>
                  <th>
                      <div id="InvoiceDropDown">
                          @Html.DropDownListFor(model => model.BAR_Clients.InvoiceMode, Model.InvoiceOptions, new { style = "width:70px" })
                      </div>
                  </th>
                  <th>
                      <button>Add Email</button>
                  </th>
              </tr>
              <tr>
                  <th align="left">
                      @Html.Raw("Enter New Email Address")
                  </th>
              </tr>
          </table>     
       }
    }
    </div>
