    using System;
    using System.Collections.Generic;
    //using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class Account
    {       
        //[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "O campo nome é obrigatório!")]
        //[System.ComponentModel.DataAnnotations.StringLength(50, ErrorMessage = "O campo nome deve possuir no máximo 50 caracteres!")]
        //[System.ComponentModel.DataAnnotations.Display(Name = "Nome")]
        public string Name { get; set; }
        //[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "O campo nome é obrigatório!")]
        //[System.ComponentModel.DataAnnotations.StringLength(100, ErrorMessage = "O campo email deve possuir no máximo 100 caracteres!")]
        //[System.ComponentModel.DataAnnotations.Display(Name = "Email")]
        public string Email { get; set; }
        //[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "O campo senha é obrigatório!")]
        //[System.ComponentModel.DataAnnotations.Display(Name = "Senha")]
        //[System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [NotMapped]
        public string Password { get; set; }
        //[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "O campo confirmação de senha é obrigatório!")]
        //[System.ComponentModel.DataAnnotations.Display(Name = "Confirmação da senha")]
        //[System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        //[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "A confirmação da senha está diferente da senha informada.")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
