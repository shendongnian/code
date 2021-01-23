    function ValidateAddNewCourseCharge() {    
    var AdminCharge = $.trim($("[id$='txtAdminCharges']").val());
    var OtherCharge = $.trim($("[id$='txtOtherCharges']").val());
    isValidDate(EffectiveDate);
    if (AdminCharge == "") {
        showErrorMessagePopUp("Please Enter Admin Charge!");
        return false;
    }
    else {
        if (IsNumeric(AdminCharge)) {
            AdminCharge = parseFloat(AdminCharge).toFixed(2);
        }
        else {
            showErrorMessagePopUp("Admin Charge is not Valid. Please try again!");
            AdminCharge = "";
            return false;
        }
    }
    if (OtherCharge == "") {
        showErrorMessagePopUp("Please Enter Other Charge!");
        return false;
    }
    else {
        if (IsNumeric(OtherCharge)) {
            OtherCharge = parseFloat(OtherCharge).toFixed(2);
        }
        else {
            showErrorMessagePopUp("Other Charge is not Valid. Please try again!");
            OtherCharge = "";
            return false;
        }
    }    
    return true;
    }
    function IsNumeric(input) {
    var RE = /^-{0,1}\d*\.{0,1}\d+$/;
    // var RE = /^-{0,1}\d*\.{0,1}\d{2}$/; To Enable user to enter only decimal number
    return (RE.test(input));
    }
