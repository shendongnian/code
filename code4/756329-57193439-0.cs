        [BindProperty]
        public InputModel UserPassword { get; set; }
    
        public class InputModel {
          [BindProperty]
          [Display(Name = "Contraseña")]
          [Required(ErrorMessage = "La contraseña es obligatoria.")]
          [RegularExpression("^[a-zA-ZñÑ0-9]+$",ErrorMessage = "Sólo se permiten letras y números.")]
          [StringLength(12,ErrorMessage = "La contraseña no debe tener más de 12 caracteres.")]
          [MaxLength(12,ErrorMessage = "La contraseña no debe tener más de 12 caracteres.")]
          [MinLength(2,ErrorMessage = "La contraseña no debe tener menos de 2 caracteres.")]
          public string Password { get; set; }
    
          [BindProperty]
          [Display(Name = "Confirmación de Contraseña")]
          [Required(ErrorMessage = "La contraseña es obligatoria.")]
          [Compare(nameof(Password),ErrorMessage = "La contraseña de confirmación no coincide.")]
          public string ConfirmPassword { get; set; }
        }
