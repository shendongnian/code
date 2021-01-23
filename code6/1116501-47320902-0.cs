    public async Task<IActionResult> ChangePassword(ChangePwdViewModel usermodel)
            {           
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _userManager.FindByIdAsync(userId);            
                var result = await _userManager.ChangePasswordAsync(user, usermodel.oldPassword, usermodel.newPassword);
                if (!result.Succeeded)
                {
                    //throw exception......
                }
                return Ok();
            }
    
    public class ChangePwdViewModel
        {  
            [DataType(DataType.Password), Required(ErrorMessage ="Old Password Required")]
            public string oldPassword { get; set; }
    
            [DataType(DataType.Password), Required(ErrorMessage ="New Password Required")]
            public string newPassword { get; set; }
        }
